import React, { FC, ReactNode, useCallback, useEffect, useState } from "react";
import {
  Button,
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
import { PrivateComponent } from "../../../helpers/privateComponent";
import { Link } from "react-router-dom";
import TagTableColumnController from "./TagTableColumnController";
import { Roles } from "../../../constants/roles";
import ManufactureTable from "../Manufacture/ManufactureTable";
import TagsTable from "./TagsTable";
import { useDispatch, useSelector } from "react-redux";
import { getTags } from "../../../services/admin/tags/tag";
import { fetch } from "../../../helpers/fetch";
import TagAction from "./TagAction";
import { ITag } from "../../../services/admin/ITag";

const Tags: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isFilterOpen, setIsFilterOpen] = useState<boolean>(false);
  const [isActionModal, setIsActionModal] = useState<boolean>(false);
  const [isDeleteModal, setIsDeleteModal] = useState<boolean>(false);
  const [isEdit, setIsEdit] = useState<boolean>(false);

  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getTags(fetch()));
  }, []);

  const { tags }: { tags: ITag[] } = useSelector((state) => ({
    tags: state.Tags.tags,
  }));

  console.log(tags);

  const handleFilterClick = () => setIsFilterOpen(!isFilterOpen);

  const onAddNewClick = () => {
    setIsEdit(false);
    console.log("isActionModal");
    actionModalToggle();
  };

  const actionModalToggle = useCallback(() => {
    if (isActionModal) {
      setIsActionModal(false);
    } else {
      setIsActionModal(true);
    }
  }, [isActionModal]);

  const handleDeleteClick = (id: string) => {};

  return (
    <div className={"page-content"}>
      <Card>
        <CardHeader>
          <h2 className={"mb-0"}>Аттрибуты</h2>
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
                      <TagTableColumnController />
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
                  <Button
                    onClick={onAddNewClick}
                    className={"fs-14 btn btn-success"}
                    roles={[Roles.Admin]}
                  >
                    <i className={"ri-add-line align-middle me-2"}></i>
                    Добавить новое...
                  </Button>
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
              <TagsTable tags={tags} handleDelete={handleDeleteClick} />
            </Col>
          </Row>
        </CardBody>
      </Card>
      <TagAction
        isEdit={isEdit}
        isOpen={isActionModal}
        toggle={actionModalToggle}
      />
    </div>
  );
};

export default Tags;
