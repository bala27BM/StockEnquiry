
export interface StockItem {
  location: string;
  locationType: string;
  availableQty: number;
  reservedQty: number;
  uom: string;
}

export interface StockResponse {
  partNumber: string;
  description: string;
  totalAvailable: number;
  totalReserved: number;
  stockDetails: StockItem[];
}
