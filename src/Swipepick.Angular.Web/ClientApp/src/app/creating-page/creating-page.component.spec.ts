import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatingPageComponent } from './creating-page.component';

describe('CreatingPageComponent', () => {
  let component: CreatingPageComponent;
  let fixture: ComponentFixture<CreatingPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreatingPageComponent]
    });
    fixture = TestBed.createComponent(CreatingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
