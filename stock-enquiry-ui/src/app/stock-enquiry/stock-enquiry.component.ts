
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { StockResponse } from './stock.model';

@Component({
  selector: 'app-stock-enquiry',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './stock-enquiry.component.html',
  styleUrl: './stock-enquiry.component.css'
})
export class StockEnquiryComponent {
  private apiUrl = 'http://localhost:5058/api/stock';

  stockForm = new FormGroup({
    partNumber: new FormControl('', Validators.required)
  });

  stock: StockResponse | null = null;
  loading = false;
  errorMessage = '';
  searchedPartNumber = '';

  constructor(private http: HttpClient) {}

  searchStock(): void {
    if (this.stockForm.invalid || this.loading) {
      this.stockForm.markAllAsTouched();
      return;
    }

    const partNumber =
      this.stockForm.controls.partNumber.value!.trim().toUpperCase();

    if (!partNumber) {
      this.stockForm.controls.partNumber.setErrors({ required: true });
      return;
    }

    this.stock = null;
    this.errorMessage = '';
    this.loading = true;
    this.searchedPartNumber = partNumber;

    this.http.get<StockResponse>(
      `${this.apiUrl}/${encodeURIComponent(partNumber)}`
    ).subscribe({
      next: (response) => {
        this.stock = response;
        this.loading = false;
      },
      error: (error: HttpErrorResponse) => {
        this.loading = false;

        if (error.status === 404) {
          this.errorMessage =
            `No stock information found for ${partNumber}.`;
        } else {
          this.errorMessage =
            'Unable to retrieve stock information. Please try again.';
        }
      }
    });
  }

  resetSearch(): void {
    this.stockForm.reset({ partNumber: '' });
    this.stock = null;
    this.errorMessage = '';
    this.loading = false;
    this.searchedPartNumber = '';
  }
}
