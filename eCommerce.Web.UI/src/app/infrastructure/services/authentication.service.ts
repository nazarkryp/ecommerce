import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Observable, ReplaySubject, Subscriber } from 'rxjs';

import * as Oidc from 'oidc-client';
import { mergeMap, tap } from 'rxjs/operators';

export interface CurrentUser {
    name: string;
}

@Injectable({
    providedIn: 'root',
})
export class AuthenticationService {
    private readonly config = {
        authority: 'https://localhost:7047',
        client_id: 'ecommerce',
        redirect_uri: 'https://localhost:44438',
        response_type: 'id_token token',
        scope: 'openid profile email api',
        post_logout_redirect_uri: 'https://localhost:44438',
    };

    private userManager: Oidc.UserManager;
    private currentUserSubject: ReplaySubject<CurrentUser> =
        new ReplaySubject<CurrentUser>();

    constructor(private route: ActivatedRoute) {
        this.userManager = new Oidc.UserManager(this.config);
    }

    public trySignIn(): Observable<any> {
        console.log('trySignIn');
        return this.signinRedirectCallback().pipe(
            mergeMap((session: any) => {
                return this.getSession().pipe(
                    tap((session: any) => {
                        if (session) {
                            this.currentUserSubject.next(session.profile);
                        }
                    })
                );
            })
        );
    }

    private signinRedirectCallback(): Observable<any> {
        return new Observable((subscriber) => {
            this.userManager.signinRedirectCallback().then(
                (session: any) => {
                    subscriber.next(session.profile);
                    subscriber.complete();
                },
                (error) => {
                    subscriber.next(null);
                    subscriber.complete();
                }
            );
        });
    }

    private getSession(): Observable<any> {
        return new Observable((subscriber) => {
            this.userManager.getUser().then(
                (session) => {
                    subscriber.next(session);
                    subscriber.complete();
                },
                (error) => {
                    subscriber.next(null);
                    subscriber.complete();
                }
            );
        });
    }

    // public getCurrentSession() {
    //     return this.replaySubject.asObservable();
    // }

    public get currentUser(): Observable<CurrentUser> {
        return this.currentUserSubject.asObservable();
    }

    public getCurrentSession(): any {
        const observable = new Observable((subscriber) => {
            this.userManager.getUser().then(
                (response) => {
                    subscriber.next(response);
                    subscriber.complete();
                },
                (err) => {
                    subscriber.complete();
                }
            );
        });

        return observable;
    }

    public signIn() {
        this.userManager.signinRedirect(this.config);
    }

    public signOut() {
        this.userManager.signoutRedirect();
    }
}
