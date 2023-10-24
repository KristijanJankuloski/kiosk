import { Route } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { RegisterComponent } from './features/auth/register/register.component';

export const appRoutes: Route[] = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'products', loadChildren: () => import('./features/product/product.module').then(m => m.ProductModule) },

    { path: '', redirectTo: '/products', pathMatch: 'full' }
];
