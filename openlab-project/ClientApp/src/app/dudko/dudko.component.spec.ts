import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DudkoComponent } from './dudko.component';

describe('DudkoComponent', () => {
  let component: DudkoComponent;
  let fixture: ComponentFixture<DudkoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DudkoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DudkoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
