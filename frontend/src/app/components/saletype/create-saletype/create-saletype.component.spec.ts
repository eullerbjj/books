import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSaleTypeComponent } from './create-saletype.component';

describe('CreateSaleTypeComponent', () => {
  let component: CreateSaleTypeComponent;
  let fixture: ComponentFixture<CreateSaleTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateSaleTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateSaleTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
