import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { PositionService, Position } from '../../services/position.service';

@Component({
  selector: 'app-position-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './position-list.component.html',
  styleUrls: ['./position-list.component.scss']
})
export class PositionListComponent implements OnInit {
  positions: Position[] = [];
  loading = true;
  error = '';

  constructor(private positionService: PositionService) {}

  ngOnInit(): void {
    this.positionService.getAll().subscribe({
      next: (positions) => {
        this.positions = positions;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load positions.';
        this.loading = false;
        console.error(err);
      }
    });
  }

  onDelete(id: string): void {
    if (confirm('Are you sure you want to delete this position?')) {
      this.positionService.delete(id).subscribe({
        next: () => {
          // After delete, refresh the list
          this.positions = this.positions.filter(p => p.id !== id);
        },
        error: (err) => {
          console.error('Failed to delete position', err);
        }
      });
    }
  }
}
