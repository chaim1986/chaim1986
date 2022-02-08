import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportVotersComponent } from './import-voters.component';

describe('ImportVotersComponent', () => {
  let component: ImportVotersComponent;
  let fixture: ComponentFixture<ImportVotersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportVotersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportVotersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
