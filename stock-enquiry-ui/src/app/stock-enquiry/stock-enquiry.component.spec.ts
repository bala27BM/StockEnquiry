import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockEnquiryComponent } from './stock-enquiry.component';

describe('StockEnquiryComponent', () => {
  let component: StockEnquiryComponent;
  let fixture: ComponentFixture<StockEnquiryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StockEnquiryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StockEnquiryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
