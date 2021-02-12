Feature: SourceFormat REST Api - Delete a SourceFormat input validation

  As a Data Owner and Data Curator
  I need to be able to delete a SourceFormat
  And I need to be able to do this data doesn't get corrupted
  So that, I need a functionality providing this.

  Scenario: SourceFormat is deleted

    Given there is a SourceFormat domain object
      | Field    | Value |
      | Name     | asd   |
      | Desc     | asd   |
      | IsActive | 0     |
      | Key      | sf    |
    And SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value     |
      | Key       | sf        |
      | ResultKey | sf-result |
    And stored SourceFormat domain object Id value is set to
      | Field     | Value     |
      | Key       | sf-result |
      | ResultKey | sf-result |
      | NewValue  | 0         |

    When SourceFormat is sent to SourceFormat endpoint delete method
      | Field     | Value            |
      | Key       | sf-result        |
      | ResultKey | sf-delete-result |

    Then SourceFormat REST Delete method returns bad request
      | Field | Value            |
      | Key   | sf-delete-result |