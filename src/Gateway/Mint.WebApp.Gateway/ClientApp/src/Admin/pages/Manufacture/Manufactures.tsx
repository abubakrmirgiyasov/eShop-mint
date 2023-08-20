import React, { FC, ReactNode, useState } from "react";
import { Error } from "../../../components/Notifications/Error";
import {
  Button,
  ButtonGroup,
  Card,
  CardBody,
  CardHeader,
  Col,
  Collapse,
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  Input,
  Row,
  Spinner,
  UncontrolledDropdown,
} from "reactstrap";
import { Roles } from "../../../constants/roles";
import { Link } from "react-router-dom";
import { PrivateComponent } from "../../../helpers/privateComponent";
import ManufactureTableColumnController from "./ManufactureTableColumnController";
import ManufactureTable from "./ManufactureTable";

const Manufactures: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const [isFilterOpen, setIsFilterOpen] = useState<boolean>(false);

  const handleFilterClick = () => setIsFilterOpen(!isFilterOpen);

  const handleDeleteClick = (id: string) => {};

  return (
    <div className={"page-content"}>
      {error && <Error message={error} />}
      <Card>
        <CardHeader>
          <h2 className={"mb-0"}>Производители</h2>
        </CardHeader>
        <CardBody>
          {isLoading ? (
            <div className={"d-flex justify-content-center align-items-center"}>
              <Spinner size={"sm"} color={"success"}>
                Loading...
              </Spinner>
            </div>
          ) : (
            <Row>
              <Col lg={12} className={"mb-3"}>
                <div className={"d-flex align-items-center"}>
                  <ButtonGroup className={"me-2"}>
                    <UncontrolledDropdown>
                      <DropdownToggle
                        tag={"button"}
                        className={"btn btn-outline-success"}
                      >
                        <i className={"ri-settings-4-line"}></i>
                      </DropdownToggle>
                      <DropdownMenu className={"dropdown-menu-md p-2"}>
                        <DropdownItem header>Вкл/Выкл столбец</DropdownItem>
                        <ManufactureTableColumnController />
                      </DropdownMenu>
                    </UncontrolledDropdown>
                  </ButtonGroup>
                  <button
                    className={"me-2 fs-14 btn btn-outline-success"}
                    onClick={handleFilterClick}
                  >
                    <i className={"ri-filter-2-line"}></i>
                  </button>
                  <PrivateComponent>
                    <Link
                      to={"/admin/manufactures/add"}
                      className={"fs-14 btn btn-success"}
                      roles={[Roles.Admin]}
                    >
                      <i className={"ri-add-line align-middle me-2"}></i>
                      Добавить новое ...
                    </Link>
                  </PrivateComponent>
                </div>
                <Collapse isOpen={isFilterOpen} horizontal={false}>
                  <div className={"d-flex mt-3"}>
                    <input
                      type={"text"}
                      className={"w-50 me-2 form-control"}
                      placeholder={"Поиск по названию"}
                    />
                    <button className={"btn btn-outline-danger"}>
                      <i className={"ri-search-2-line"}></i>
                    </button>
                  </div>
                </Collapse>
              </Col>
              <Col lg={12}>
                <ManufactureTable handleDelete={handleDeleteClick} />
              </Col>
            </Row>
          )}
        </CardBody>
      </Card>
    </div>
  );
};

export default Manufactures;
