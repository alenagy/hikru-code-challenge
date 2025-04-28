import { HttpInterceptorFn } from '@angular/common/http';

export const ApiKeyInterceptor: HttpInterceptorFn = (req, next) => {
  const cloned = req.clone({
    setHeaders: {
      'X-API-KEY': 'da1d2d28-92ed-4a2e-a1a9-10fcf4425f15'
    }
  });

  return next(cloned);
};