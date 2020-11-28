import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RightSidebarListFriendComponent } from './right-sidebar-list-friend.component';

describe('RightSidebarListFriendComponent', () => {
  let component: RightSidebarListFriendComponent;
  let fixture: ComponentFixture<RightSidebarListFriendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RightSidebarListFriendComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RightSidebarListFriendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
