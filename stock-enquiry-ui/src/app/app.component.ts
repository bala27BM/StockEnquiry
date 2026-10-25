
import { Component } from '@angular/core';
import { StockEnquiryComponent } from './stock-enquiry/stock-enquiry.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [StockEnquiryComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {}
