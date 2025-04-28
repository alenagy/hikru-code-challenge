import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PositionFormComponent } from './position-form.component';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting, HttpTestingController } from '@angular/common/http/testing';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

describe('PositionFormComponent', () => {
  let fixture: ComponentFixture<PositionFormComponent>;
  let component: PositionFormComponent;
  let httpTesting: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PositionFormComponent, CommonModule, ReactiveFormsModule],
      providers: [
        provideHttpClient(),
        provideHttpClientTesting(),
        provideRouter([])
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(PositionFormComponent);
    component = fixture.componentInstance;
    httpTesting = TestBed.inject(HttpTestingController);
    fixture.detectChanges();
  });

  afterEach(() => {
    httpTesting.verify();
  });

  it('should create the component', () => {
    const isEdit = fixture.componentInstance.isEdit;

    if (isEdit) {
      const req = httpTesting.expectOne((r) => r.method === 'GET');
      req.flush({}); // Fake load position if edit mode
    }

    expect(component).toBeTruthy();
  });
});
