export interface OrderItem {
  dishId: string;
  dishName: string;
  unitPrice: number;
  quantity: number;
  note: string;
  subtotal: number;
}

export interface Order {
  id: string;
  number: number;
  tableId: string;
  tableName: string;
  waiterName: string;
  status: string;
  createdAt: string;
  items: OrderItem[];
  total: number;
}
