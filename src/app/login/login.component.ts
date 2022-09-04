import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  password: string = "";
  username: string = "";

  ngOnInit() {

  }

  invalidlogin: boolean = true;

  BaseURL: string = "";

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseURL = baseUrl;
  }

 

  login() {

    /*  login() {*/
    const cred = {
      'username': this.username, /*form.value.username*/
      'password': this.password
    }

    this.http.post('http://localhost:5123/api/auth/login', cred)
      .subscribe(response => {
        const token = (<any>response).token;
        localStorage.setItem("jwt", token);
        this.invalidlogin = false;
        //this.globalEventsManager.showNavBar(true);        
        this.router.navigate(['Home']);

      }, err => {
        alert("Unable to Login");
        this.invalidlogin = true;
      });
  }

  registeruser() {

    this.router.navigate(['Register']);
  }




}
