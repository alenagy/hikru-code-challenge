import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { PositionService } from '../../services/position.service';

@Component({
  selector: 'app-position-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './position-form.component.html',
  styleUrls: ['./position-form.component.scss']
})
export class PositionFormComponent implements OnInit {
  form!: FormGroup;
  isEdit = false;
  id: string | null = null;
  loading = true;
  error = '';

  constructor(
    private fb: FormBuilder,
    private positionService: PositionService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      location: ['', Validators.required],
      status: ['Open', Validators.required],
      recruiterId: ['', Validators.required],
      departmentId: ['', Validators.required],
      budget: [0, Validators.required],
      closingDate: ['']
    });

    this.id = this.route.snapshot.paramMap.get('id');
    this.isEdit = !!this.id;

    if (this.isEdit && this.id) {
      this.positionService.getById(this.id).subscribe({
        next: (position) => {
          this.form.patchValue(position);
          this.loading = false;
        },
        error: (err) => {
          this.error = 'Failed to load position.';
          this.loading = false;
          console.error(err);
        }
      });
    } else {
      this.loading = false;
    }
  }

  onSubmit(): void {
    if (this.form.invalid) {
      return;
    }

    const positionData = this.form.value;

    if (this.isEdit && this.id) {
      this.positionService.update(this.id, positionData).subscribe({
        next: () => this.router.navigate(['/positions']),
        error: (err) => {
          this.error = 'Failed to update position.';
          console.error(err);
        }
      });
    } else {
      this.positionService.create(positionData).subscribe({
        next: () => this.router.navigate(['/positions']),
        error: (err) => {
          this.error = 'Failed to create position.';
          console.error(err);
        }
      });
    }
  }
}
