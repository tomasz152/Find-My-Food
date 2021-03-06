import { Component, Inject } from "@angular/core";
import { Http } from "@angular/http";
import {
    FormGroup,
    FormControl,
    Validators
} from "@angular/forms";

@Component({
    moduleId: module.id + "",
    selector: "profile",
    templateUrl: "./profile.component.html"
})
export class ProfileComponent {
    restaurant: IRestaurantFull;
    selectedItems: any;
    ports: { [index: number]: string; value: string;key: number }[];
    myform: FormGroup;
    dropdownPortSettings: any = {};

    updateProfileInfo() {
        this.http.get("api/GetExtendedRestaurant").subscribe(result => {
                this.restaurant = result.json() as IRestaurantFull;
            },
            error => console.error(error));
    }

    constructor(private http: Http, @Inject("BASE_URL") baseUrl: string) {
        http.get(baseUrl + "api/GetExtendedRestaurant").subscribe(result => {
                this.restaurant = result.json() as IRestaurantFull;
                this.ports = [
                    { value: "https", key: 0 },
                    { value: "http", key: 1 }
                ];
                var port = this.ports[0].value;
                if (this.restaurant.website == null)
                    this.restaurant.website = "";
                for (let port1 of this.ports)
                    if (this.restaurant.website.search(port1.value + "://") != -1) {
                        port = port1.value;
                        break;
                    }
                this.dropdownPortSettings = {
                    singleSelection: true,
                    text: "https",
                    primaryKey: "key",
                    labelKey: "value",
                    enableSearchFilter: false
                };
                this.myform = new FormGroup({
                    name: new FormControl(this.restaurant.name,
                        [
                            Validators.required
                        ]),
                    ceofirstname: new FormControl(this.restaurant.ceofirstname),
                    ceolastname: new FormControl(this.restaurant.ceolastname),
                    address: new FormControl(this.restaurant.address),
                    city: new FormControl(this.restaurant.city),
                    country: new FormControl(this.restaurant.country),
                    postalCode: new FormControl(this.restaurant.postalCode),
                    //longitude: number;
                    //latitude: number;
                    longDescription: new FormControl(this.restaurant.longDescription),
                    motto: new FormControl(this.restaurant.motto),
                    website: new FormControl(this.restaurant.website.replace("https://", "").replace("http://", "")),
                    county: new FormControl(this.restaurant.county),
                    street: new FormControl(this.restaurant.street),
                    streetNumber: new FormControl(this.restaurant.streetNumber),
                    province: new FormControl(this.restaurant.province),
                    port: new FormControl(port,)
                });
            },
            error => console.error(error));
    }


    onSubmit() {
        console.log("sumbit");
        console.log(this.myform.value.port);
        if (this.myform.value.port == null)
            this.myform.value.port = [this.ports[0]];
        
            this.myform.value.website = this.myform.value.port[0].value + "://" + this.myform.value.website;
        this.myform.value.address = this.getFullAddress(this.myform.value);
        console.log(this.myform.value);
        this.http.post("/api/UpdateProfile", this.myform.value).subscribe((val: any): void => {
                const response = val.json() as IStandardResponse;
                if (response.response) {
                    this.updateProfileInfo();
                    alert("zaktualizowano");
                } else
                    alert(`Niepowodzenie z powodu: ${response.message}`);
            },
            response => {
                console.log("POST call in error", response);
            },
            () => {
                console.log("The POST observable is now completed.");
            });
        this.myform.value.website = this.myform.value.website.replace("https://", "").replace("http://", "");
    }

    getFullAddress(value: any): string {
        return value.street +
            " " +
            value.streetNumber +
            ", " +
            value.postalCode +
            " " +
            value.city +
            ", " +
            value.country;
    }
}

interface ISingleRate {
    login: string;
    rate: number;
}

interface IRestaurantFull extends IRestaurantInfo {
    email: string;
    longitude: number;
    latitude: number;
    nopromotions: number;
    rating: number;
    norates: number;
    lastRates: ISingleRate[];
}

interface IRestaurantInfo {
    name: string;
    ceofirstname: string;
    ceolastname: string;
    address: string;
    city: string;
    country: string;
    postalCode: string;
    //longitude: number;
    //latitude: number;
    longDescription: string;
    motto: string;
    website: string;
    county: string;
    street: string;
    streetNumber: string;
    province: string;
}

interface IStandardResponse {
    response: boolean,
    message: string,
}