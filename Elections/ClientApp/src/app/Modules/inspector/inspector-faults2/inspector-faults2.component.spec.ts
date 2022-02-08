import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectorFaults2Component } from './inspector-faults2.component';

describe('InspectorFaults2Component', () => {
  let component: InspectorFaults2Component;
  let fixture: ComponentFixture<InspectorFaults2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InspectorFaults2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectorFaults2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
