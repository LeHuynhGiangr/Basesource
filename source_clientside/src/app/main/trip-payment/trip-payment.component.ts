import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import {ICreateOrderRequest, IPayPalConfig} from 'ngx-paypal';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {STEPPER_GLOBAL_OPTIONS} from '@angular/cdk/stepper';
import { Trips } from '../../_core/models/trip.model';
import { TripStatic } from '../../_core/data-repository/trip';
@Component({
    selector: 'app-trip-payment',
    templateUrl: './trip-payment.component.html',
    styleUrls: ['./trip-payment.component.css'],
    providers: [{
        provide: STEPPER_GLOBAL_OPTIONS, useValue: {showError: true}
      }]
})
export class TripPaymentComponent implements OnInit {
    public payPalConfig ?: IPayPalConfig;
    firstFormGroup: FormGroup;
    secondFormGroup: FormGroup;
    thirdFormGroup: FormGroup;
    check:boolean
    public trips :Trips;
    cost:number
    total:number
    people:number=1
    
    constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc,private _formBuilder: FormBuilder ) {}

    ngOnInit() {
      var script = document.createElement("script");
      script.type = "text/javascript";
      script.src = "../assets/js/script.js";
      this.elementRef.nativeElement.appendChild(script);
      this.initConfig();
      this.trips = new Trips()
      this.trips.Id = TripStatic.Id
      this.trips.Name = TripStatic.Name
      this.trips.Description = TripStatic.Description
      this.trips.Cost = TripStatic.Cost
      this.cost = parseInt(this.trips.Cost)/10
      this.total = (this.cost + parseInt(this.trips.Cost))*this.people
      this.trips.Departure = TripStatic.Departure
      this.trips.Destination = TripStatic.Destination
      this.trips.Policy = TripStatic.Policy
      this.trips.InfoContact = TripStatic.InfoContact
      this.trips.Days = TripStatic.Days
      this.trips.DateStart = TripStatic.DateStart
      this.trips.DateEnd = TripStatic.DateEnd
      this.trips.Service = TripStatic.Service
      this.check=false
      this.firstFormGroup = this._formBuilder.group({
        firstCtrl: ['', Validators.required]
      });
      this.secondFormGroup = this._formBuilder.group({
        secondCtrl: ['', Validators.required]
      });
      this.thirdFormGroup = this._formBuilder.group({
        thirdCtrl: ['', Validators.required]
      });
    }
    successfully(){
        this.check=true
    }
    valuechange(newValue) {
        this.total = (this.cost + parseInt(this.trips.Cost))*newValue
    }
    private initConfig(): void {
        this.payPalConfig = {
          currency: 'USD',
          clientId: 'AdwX6ZgL8Z2IgAJeIZkfrKqKQNNA64tkKCyoE2ClKcO9S1EpHyaLxBdcDqQAaY92eCK69DwGSL47_j_0', // add paypal clientId here
          createOrderOnClient: (data) => <ICreateOrderRequest> {
            intent: 'CAPTURE',
            purchase_units: [{
              amount: {
                currency_code: 'USD',
                value: this.total.toString(),
                breakdown: {
                  item_total: {
                    currency_code: 'USD',
                    value: this.total.toString()
                  }
                }
              },
              items: [{
                name: this.trips.Name,
                quantity: this.people.toString(),
                category: 'DIGITAL_GOODS',
                unit_amount: {
                  currency_code: 'USD',
                  value: this.trips.Cost.toString(),
                },
              }]
            }]
          },
          advanced: {
            commit: 'true'
          },
          style: {
            label: 'paypal',
            layout: 'vertical',
            size: 'small',
            color: 'blue',
            shape: 'rect'
          },
          onApprove: (data, actions) => {
            console.log('onApprove - transaction was approved, but not authorized', data, actions);
            actions.order.get().then(details => {
              console.log('onApprove - you can get full order details inside onApprove: ', details);
            });
    
          },
          onClientAuthorization: (data) => {
            console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
            if(data["status"]=="COMPLETED")
                alert("Payment successfully")
          },
          onCancel: (data, actions) => {
            console.log('OnCancel', data, actions);
    
          },
          onError: err => {
            console.log('OnError', err);
          },
          onClick: (data, actions) => {
            console.log('onClick', data, actions);
          }
        };
      }
}
