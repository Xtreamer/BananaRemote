import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    constructor(
        private http: Http,
        @Inject('BASE_URL') private baseUrl: string) {
    }

    tryPostOn = () => {
        console.log("posting on!!");
        this.http.post(this.baseUrl + 'api/WebHooks/TryPostOn', {}).subscribe(result => {
            console.log("post on succeeded");
        }, error => console.error(error));
    }

    tryPostOff = () => {
        console.log("posting off!!");
        this.http.post(this.baseUrl + 'api/WebHooks/TryPostOff', {}).subscribe(result => {
            console.log("post off succeeded");
        }, error => console.error(error));
    }
}
