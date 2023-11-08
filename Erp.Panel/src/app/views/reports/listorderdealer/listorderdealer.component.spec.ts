import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListorderdealerComponent } from './listorderdealer.component';

describe('ListorderdealerComponent', () => {
  let component: ListorderdealerComponent;
  let fixture: ComponentFixture<ListorderdealerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListorderdealerComponent]
    });
    fixture = TestBed.createComponent(ListorderdealerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
