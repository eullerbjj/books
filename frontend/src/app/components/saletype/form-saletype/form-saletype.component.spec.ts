import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormSaleTypeComponent } from './form-saletype.component';

describe('FormSaleTypeComponent', () => {
  let component: FormSaleTypeComponent;
  let fixture: ComponentFixture<FormSaleTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormSaleTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormSaleTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
