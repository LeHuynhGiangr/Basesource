import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersListTripComponent } from './users-list-trip.component';

describe('UsersListTripComponent', () => {
  let component: UsersListTripComponent;
  let fixture: ComponentFixture<UsersListTripComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersListTripComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersListTripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
