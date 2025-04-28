import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PositionListComponent } from './position-list.component';
import { CommonModule } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting, HttpTestingController } from '@angular/common/http/testing';
import { provideRouter } from '@angular/router';

describe('PositionListComponent', () => {
  let fixture: ComponentFixture<PositionListComponent>;
  let component: PositionListComponent;
  let httpTesting: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PositionListComponent, CommonModule],
      providers: [
        provideHttpClient(),
        provideHttpClientTesting(), // ✅ allows HttpClient interception/mocking
        provideRouter([])
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(PositionListComponent);
    component = fixture.componentInstance;
    httpTesting = TestBed.inject(HttpTestingController); // ✅ inject testing controller

    fixture.detectChanges();
  });

  afterEach(() => {
    httpTesting.verify(); // ✅ ensure no pending HTTP requests after each test
  });

  it('should create the component', () => {
    // Provide a fake HTTP response when the component calls getAll()
    const req = httpTesting.expectOne('https://localhost:7252/api/Positions');
    expect(req.request.method).toBe('GET');
    req.flush([]); // Respond with an empty array

    expect(component).toBeTruthy();
  });
});
