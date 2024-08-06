import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SaleType } from '../models/saletype.model';
import { SaleTypePayload } from '../models/payloads/saletype.payload';

@Injectable({
  providedIn: 'root'
})
export class SaleTypeService {
  private apiUrl = 'https://localhost:7043/saletypes';

  http = inject(HttpClient);

  getSaleTypes(): Observable<SaleType[]> {
    return this.http.get<SaleType[]>(this.apiUrl);
  }

  getSaleType(id: number): Observable<SaleType> {
    return this.http.get<SaleType>(`${this.apiUrl}/${id}`);
  }

  createSaleType(saleType: SaleTypePayload): Observable<void> {
    return this.http.post<void>(this.apiUrl, saleType);
  }

  updateSaleType(id: number, saleType: SaleTypePayload): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}`, saleType);
  }

  deleteSaleType(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
