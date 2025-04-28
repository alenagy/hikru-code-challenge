import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { PositionListComponent } from './app/positions/list/position-list.component';
import { PositionDetailComponent } from './app/positions/detail/position-detail.component';
import { PositionFormComponent } from './app/positions/form/position-form.component';
import { provideAnimations } from '@angular/platform-browser/animations';
import { ApiKeyInterceptor } from './app/core/api-key.interceptor';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter([
      { path: '', component: PositionListComponent },
      { path: 'positions', component: PositionListComponent },
      { path: 'positions/create', component: PositionFormComponent },
      { path: 'positions/:id', component: PositionDetailComponent },
      { path: 'positions/:id/edit', component: PositionFormComponent }
    ]),
    provideHttpClient(
      withInterceptors([ApiKeyInterceptor])
    ),
    provideAnimations()
  ]
});