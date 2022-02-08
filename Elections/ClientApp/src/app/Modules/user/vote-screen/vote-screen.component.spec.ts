import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VoteScreenComponent } from './vote-screen.component';

describe('VoteScreenComponent', () => {
  let component: VoteScreenComponent;
  let fixture: ComponentFixture<VoteScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VoteScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VoteScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
