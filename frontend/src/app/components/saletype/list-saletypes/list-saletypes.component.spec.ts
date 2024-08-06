import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListSaleTypesComponent } from './list-saletypes.component';

describe('ListSaleTypesComponent', () => {
  let component: ListSaleTypesComponent;
  let fixture: ComponentFixture<ListSaleTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListSaleTypesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListSaleTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
