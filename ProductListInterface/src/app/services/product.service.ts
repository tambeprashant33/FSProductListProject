import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
export interface Product {
  id?: number;
  name: string;
  price: number;
}

@Injectable({ providedIn: 'root' })
export class ProductService {
  private productsSubject = new BehaviorSubject<Product[]>([]);
  public products$ = this.productsSubject.asObservable();
  private apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  loadProducts() {
    // this.http
    //   .get<Product[]>('/api/product/GetProductDetails')
    //   .subscribe((data) => this.productsSubject.next(data));
    // this.http
    //   .get<Product[]>('/api/product/GetProductDetails')
    //   .subscribe((data) => this.productsSubject.next(data));
    this.http
      .get<Product[]>(`${this.apiUrl}/product/GetProductDetails`)
      .subscribe((data) => this.productsSubject.next(data));
  }

  addProduct(product: Product) {
    // return this.http
    //   .post<Product>('/api/product/AddProduct', product)
    //   .pipe(tap(() => this.loadProducts()));
    // return this.http
    //   .post<Product>('/api/product/AddProduct', product)
    //   .pipe(tap(() => this.loadProducts()));
    return this.http
      .post<Product>(`${this.apiUrl}/product/AddProduct`, product)
      .pipe(tap(() => this.loadProducts()));
  }
}
