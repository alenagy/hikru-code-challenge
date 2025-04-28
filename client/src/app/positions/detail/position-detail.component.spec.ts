import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PositionDetailComponent } from './position-detail.component';
import { CommonModule } from '@angular/common';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting, HttpTestingController } from '@angular/common/http/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('PositionDetailComponent', () => {
  let fixture: ComponentFixture<PositionDetailComponent>;
  let component: PositionDetailComponent;
  let httpTesting: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PositionDetailComponent, CommonModule],
      providers: [
        provideHttpClient(),
        provideHttpClientTesting(),
        provideRouter([]),
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: {
                get: (key: string) => 'fake-id' // always returns 'fake-id'
              }
            }
          }
        }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(PositionDetailComponent);
    component = fixture.componentInstance;
    httpTesting = TestBed.inject(HttpTestingController);

    fixture.detectChanges();
  });

  afterEach(() => {
    httpTesting.verify();
  });

  it('should create the component', () => {
    // Now the component WILL call a GET with id = 'fake-id'
    const req = httpTesting.expectOne((r) => r.method === 'GET');
    req.flush({}); // provide fake position data

    expect(component).toBeTruthy();
  });
});
