import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ServiceResponse } from '../models/ServiceResponse';
import { AppComponent } from '../app.component';
declare let alertify: any;
@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent extends AppComponent implements OnInit {
  public orders: any = [];
  public orderStatutes: any = [];
  public selectedOrder: any = {};

  public displayStyle: string = "none";
  constructor(private httpClient: HttpClient) {
    super();
  }

  ngOnInit(): void {
    this.getApiUrl();
    this.getOrders();
    this.getOrderStatuts();
  }

  getOrders() {
    var path = "order/";
    return this.httpClient.get(this.apiUrl + path).subscribe(data => {
      debugger
      this.orders = data;
    });
  }

  setSelectedOrder(order: any) {
    debugger
    this.selectedOrder = order;
  }

  openPopup() {
    this.displayStyle = "block";
  }
  closePopup() {
    this.displayStyle = "none";
  }

  setOrderStatus() {
    var path = "orderStatus/";
    return this.httpClient.put(this.apiUrl + path, { orderId: this.selectedOrder.id, statusId: this.selectedOrder.orderStatusId }).subscribe(data => {
      var serviceResponse = data as ServiceResponse;

      if (serviceResponse.status == 1) {
        this.getOrders();
        alertify.success(serviceResponse.message);
        this.selectedOrder = {};
        this.closePopup();
      } else {
        alertify.alert(serviceResponse.message);
      }

    });
  }

  getOrderStatuts() {
    debugger
    var path = "orderStatus/";
    return this.httpClient.get(this.apiUrl + path).subscribe(data => {
      this.orderStatutes = data;
    }, err => {
    });
  }

}
