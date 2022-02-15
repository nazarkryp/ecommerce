import { Injectable } from '@angular/core';
import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
} from '@angular/common/http';

import { Observable } from 'rxjs';
import { mergeMap, map } from 'rxjs/operators';
import { AuthenticationService } from 'app/infrastructure/services';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) {}

    public intercept(
        req: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        return this.authenticationService.getCurrentSession().pipe(
            mergeMap((session: any) => {
                if (!session) {
                    return next.handle(req);
                }

                const request = req.clone({
                    setHeaders: {
                        Authorization: `Bearer ${session['access_token']}`,
                    },
                });

                return next.handle(request);
            })
        );
    }
}
