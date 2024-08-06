import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSaleTypeComponent } from './update-saletype.component';

describe('UpdateSaleTypeComponent', () => {
  let component: UpdateSaleTypeComponent;
  let fixture: ComponentFixture<UpdateSaleTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateSaleTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateSaleTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
