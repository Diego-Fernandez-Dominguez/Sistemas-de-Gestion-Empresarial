import { injectable } from "inversify";

@injectable()
export class BaseApi {
    private readonly BASE_URL = "https://dferdom-bwccctb4hxcngufd.francecentral-01.azurewebsites.net/"

    public getUrl(endpoint: string): string {
        const url = new URL(endpoint, this.BASE_URL)
        return url.toString();
    }

    public getDefaultHeaders(): HeadersInit {
        return {
            "Content-Type": "application/json"
        };
    }

}