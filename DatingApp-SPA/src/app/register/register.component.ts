import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../_services/auth.service';

// to add a property you need to make a @Output() variable that is a new event emmiter
// then add the variabel as a method to a method as seen in cancel
// then in the parent component you add a (variabel name)="methodName($event) property to the child component tag"

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor( private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      console.log('registration successful');
    }, error => {
      console.log(error);
    })
  }

  cancel() {
    this.cancelRegister.emit(false)
    console.log('canceled');
  }

}
