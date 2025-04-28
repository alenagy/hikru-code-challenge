import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { PositionService, Position } from '../../services/position.service';

@Component({
  selector: 'app-position-detail',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './position-detail.component.html',
  styleUrls: ['./position-detail.component.scss']
})
export class PositionDetailComponent implements OnInit {
  position: Position | null = null;
  loading = true;
  error = '';

  constructor(
    private positionService: PositionService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.positionService.getById(id).subscribe({
        next: (position) => {
          this.position = position;
          this.loading = false;
        },
        error: (err) => {
          this.error = 'Failed to load position.';
          this.loading = false;
          console.error(err);
        }
      });
    }
  }
}
