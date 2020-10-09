import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PeatComponent } from './peat.component';

describe('PeatComponent', () => {
  let component: PeatComponent;
  let fixture: ComponentFixture<PeatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PeatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PeatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
