import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;
  values: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }
  

  getValues() {
    // get request go and return as a json but the return is a observable json
    this.http.get('http://localhost:3000/api/values').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
  }

}
