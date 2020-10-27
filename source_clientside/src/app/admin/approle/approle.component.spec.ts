import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproleComponent } from './approle.component';

describe('ApproleComponent', () => {
  let component: ApproleComponent;
  let fixture: ComponentFixture<ApproleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApproleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
