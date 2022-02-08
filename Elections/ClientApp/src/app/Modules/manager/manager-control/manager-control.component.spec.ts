import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerControlComponent } from './manager-control.component';

describe('ManagerControlComponent', () => {
  let component: ManagerControlComponent;
  let fixture: ComponentFixture<ManagerControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagerControlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
