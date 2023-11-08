import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditdealerComponent } from './editdealer.component';

describe('EditdealerComponent', () => {
  let component: EditdealerComponent;
  let fixture: ComponentFixture<EditdealerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditdealerComponent]
    });
    fixture = TestBed.createComponent(EditdealerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
