import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GulidDetailsComponent } from './gulid-details.component';

describe('GulidDetailsComponent', () => {
  let component: GulidDetailsComponent;
  let fixture: ComponentFixture<GulidDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GulidDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GulidDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
