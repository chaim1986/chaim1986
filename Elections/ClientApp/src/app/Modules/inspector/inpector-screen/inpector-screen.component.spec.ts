import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InpectorScreenComponent } from './inpector-screen.component';

describe('InpectorScreenComponent', () => {
  let component: InpectorScreenComponent;
  let fixture: ComponentFixture<InpectorScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InpectorScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InpectorScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
