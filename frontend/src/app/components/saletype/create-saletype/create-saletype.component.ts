import { Component, inject } from '@angular/core';
import { SaleTypeService } from '../../../services/saletype.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormSaleTypeComponent } from "../form-saletype/form-saletype.component";
import { SaleType } from '../../../models/saletype.model';

@Component({
  selector: 'app-create-saletype',
  standalone: true,
  imports: [FormSaleTypeComponent],
  providers: [HttpClient],
  templateUrl: './create-saletype.component.html',
  styleUrl: './create-saletype.component.css'
})
export class CreateSaleTypeComponent {

  saletypeService = inject(SaleTypeService);
  router = inject(Router);

  onSubmit(saletype: SaleType) {
    this.saletypeService.createSaleType(saletype).subscribe(() => {
      this.router.navigateByUrl('/tipo-venda')
    })
  }
}
