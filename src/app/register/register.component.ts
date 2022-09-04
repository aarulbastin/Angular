import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  password: string = "";
  confirmpassword: string = "";
  username: string = "";
  salary: number = 0;
  BaseURL: string = "";

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseURL = baseUrl;
  }

  ngOnInit(): void {
  }

  Register() {
    const cred = {
      'ID' : 0,
      'Name': this.username, /*form.value.username*/
      'password': this.password,      
      'Salary': this.salary
    }
    if (this.confirmpassword != cred.password) {
      alert('Password and Confirm password not matched');
      return false;
    }
    this.http.post('http://localhost:5123/api/auth/register', cred)
      .subscribe(response => {
        alert("Registration successfull!");
        this.router.navigate(['']);
      }, err => {
        alert("Unable to Register user!");
        this.router.navigate(['']);
      });
    return true;
  }

}

