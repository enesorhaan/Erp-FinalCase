import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListdealerComponent } from './listdealer.component';

describe('ListdealerComponent', () => {
  let component: ListdealerComponent;
  let fixture: ComponentFixture<ListdealerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListdealerComponent]
    });
    fixture = TestBed.createComponent(ListdealerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
