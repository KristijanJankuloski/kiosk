import { Route } from '@angular/router';

export const appRoutes: Route[] = [
    { path: 'products', loadChildren: () => import('./features/product/product.module').then(m => m.ProductModule) },

    { path: '', redirectTo: '/products', pathMatch: 'full' }
];
