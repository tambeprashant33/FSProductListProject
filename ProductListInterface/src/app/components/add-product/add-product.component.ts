import { Component } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss'],
})
export class AddProductComponent {
  name = '';
  price = 0;

  constructor(private productService: ProductService) {}

  addProduct() {
    this.productService
      .addProduct({ name: this.name, price: this.price })
      .subscribe();
  }
}
