import React, { FC, ReactNode, useState } from "react";
import { Error } from "../../../components/Notifications/Error";
import {
  ButtonGroup,
  Card,
  CardBody,
  CardHeader,
  Col,
  Collapse,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  Row,
  UncontrolledDropdown,
} from "reactstrap";
import ManufactureTableColumnController from "../Manufacture/ManufactureTableColumnController";
import { PrivateComponent } from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/roles";
import { Link } from "react-router-dom";

const Categories: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const [isFilterOpen, setIsFilterOpen] = useState<boolean>(false);

  const handleFilterClick = () => setIsFilterOpen(!isFilterOpen);

  return (
    <div className={"page-content"}>
      {error && <Error message={error} />}
      <Card>
        <CardHeader>
          <h2 className={"mb-0"}>Категории</h2>
        </CardHeader>
        <CardBody>
          <Row>
            <Col lg={12}>
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
                    to={"/admin/categories/add"}
                    className={"fs-14 btn btn-success me-2"}
                    roles={[Roles.Admin]}
                  >
                    <i className={"ri-add-line align-middle me-2"}></i>
                    Добавить новое ...
                  </Link>
                  <Link
                    to={"/admin/categories/add/subcategory"}
                    className={"fs-14 btn btn-danger"}
                    roles={[Roles.Admin]}
                  >
                    Добавить под категории...
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
          </Row>
        </CardBody>
      </Card>
    </div>
  );
};

export default Categories;
