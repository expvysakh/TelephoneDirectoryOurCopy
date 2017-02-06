/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DirectoryListService } from './directory-list.service';

describe('DirectoryListService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DirectoryListService]
    });
  });

  it('should ...', inject([DirectoryListService], (service: DirectoryListService) => {
    expect(service).toBeTruthy();
  }));
});
