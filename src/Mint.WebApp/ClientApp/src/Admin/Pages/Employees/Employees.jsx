import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Collapse,
  Input,
  Row,
  Spinner,
} from "reactstrap";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import { Link } from "react-router-dom";
import { Roles } from "../../../constants/Roles";
import EmployeesTable from "../../components/Tables/EmployeesTable";
import Select from "react-select";
import PrivateComponent from "../../../helpers/privateComponent";
import Flatpickr from "react-flatpickr";

const Employees = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [employees, setEmployees] = useState([]);
  const [isFilterOpen, setIsFilterOpen] = useState(false);

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/employee/getemployees")
      .then((response) => {
        setIsLoading(false);
        setEmployees(response);
      })
      .catch((error) => {
        setError(error);
        setIsLoading(false);
      });
  }, []);

  return (
    <div className={"page-content"}>
      {error ? <Error message={error} /> : null}
      <Card>
        <CardHeader>
          <h2>Управление сотрудниками</h2>
        </CardHeader>
        <CardBody>
          {isLoading ? (
            <div className={"d-flex justify-content-center"}>
              {" "}
              <Spinner size={"sm"} color={"success"}>
                Loading...
              </Spinner>
            </div>
          ) : (
            <Row>
              <Col lg={12}>
                <div className="d-flex align-items-center">
                  <Button
                    className="me-2 fs-14"
                    color="primary"
                    onClick={() => setIsFilterOpen(!isFilterOpen)}
                  >
                    <i className="ri-filter-2-line"></i>
                  </Button>
                  <PrivateComponent>
                    <Link
                      to="/admin/customer/add"
                      className="fs-14 btn btn-success"
                      roles={[Roles.Admin]}
                    >
                      <i className="ri-add-line align-middle"></i> Добавить
                      сотрудника ...
                    </Link>
                  </PrivateComponent>
                </div>
                <Collapse isOpen={isFilterOpen}>
                  <div className="d-flex mt-3">
                    <Input
                      type="text"
                      className="w-25 me-3"
                      placeholder="Поиск по названию"
                    />
                    <Input
                      type="text"
                      className="w-25 me-3"
                      placeholder="Поиск по артиклу"
                    />
                    <div className="col-sm-auto me-3 w-25">
                      <div className="input-group">
                        <Flatpickr
                          className="form-control dash-filter-picker"
                          options={{
                            mode: "range",
                            dateFormat: "d M, Y",
                            defaultDate: ["01 Jan 2022", "31 Jan 2022"],
                          }}
                        />
                        <div className="input-group-text bg-primary border-primary text-white">
                          <i className="ri-calendar-2-line"></i>
                        </div>
                      </div>
                    </div>
                    <Select className={"me-3"} />
                    <Button color="danger">
                      <i className="ri-search-2-line"></i>
                    </Button>
                  </div>
                </Collapse>
              </Col>
              <Col lg={12}>
                <EmployeesTable employees={employees} />
              </Col>
            </Row>
          )}
        </CardBody>
      </Card>
    </div>
  );
};

export default Employees;
