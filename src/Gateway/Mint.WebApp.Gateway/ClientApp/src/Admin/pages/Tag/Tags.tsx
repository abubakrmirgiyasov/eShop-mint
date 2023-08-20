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
import TagTableColumnController from "./TagTableColumnController";
import { Roles } from "../../../constants/roles";
import TagsTable from "./TagsTable";
import { useDispatch, useSelector } from "react-redux";
import { getTags } from "../../../services/admin/tags/tag";
import { fetch } from "../../../helpers/fetch";
import TagAction from "./TagAction";
import { ITag } from "../../../services/admin/ITag";
import Loader from "../../../components/Common/Loader";
import { Colors } from "../../../services/types/ICommon";
import TagDelete from "./TagDelete";

const Tags: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isFilterOpen, setIsFilterOpen] = useState<boolean>(false);
  const [isActionModal, setIsActionModal] = useState<boolean>(false);
  const [isDeleteModal, setIsDeleteModal] = useState<boolean>(false);
  const [isEdit, setIsEdit] = useState<boolean>(false);
  const [id, setId] = useState<string>("");
  const [singleTag, setSingleTag] = useState<ITag>(null);

  const dispatch = useDispatch();

  const { tags }: { tags: ITag[] } = useSelector((state) => ({
    tags: state.Tags.tags,
  }));

  useEffect(() => {
    console.log("ddddddddddddddddddddddd");
    setIsLoading(true);
    dispatch(getTags(fetch()))
      .then(() => {
        setIsLoading(false);
      })
      .catch(() => setIsLoading(false));
  }, [dispatch]);

  console.log(tags);

  const handleFilterClick = () => setIsFilterOpen(!isFilterOpen);

  const onAddNewClick = () => {
    setIsEdit(false);
    actionModalToggle();
  };

  const handleDeleteClick = (id: string) => {
    setId(id);
    deleteModalToggle();
  };

  const handleChangeClick = (tag: ITag) => {
    setSingleTag(tag);
    setIsEdit(true);
    actionModalToggle();
  };

  const handleTableControllerClick = (position: number) => {
    switch (position) {
      case 0:
        console.log(0);
        break;
      case 1:
        console.log(1);
        break;
    }
  };

  const actionModalToggle = useCallback(() => {
    if (isActionModal) {
      setIsActionModal(false);
    } else {
      setIsActionModal(true);
    }
  }, [isActionModal]);

  const deleteModalToggle = useCallback(() => {
    if (isDeleteModal) {
      setIsDeleteModal(false);
    } else {
      setIsDeleteModal(true);
    }
  }, [isDeleteModal]);

  return (
    <div className={"page-content"}>
      <Card>
        <CardHeader>
          <h2 className={"mb-0"}>Атрибуты</h2>
        </CardHeader>
        <CardBody>
          {isLoading ? (
            <Loader color={Colors.success} isCenter={true} />
          ) : (
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
                        <TagTableColumnController
                          onClick={handleTableControllerClick}
                        />
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
                <TagsTable
                  tags={tags}
                  handleDelete={handleDeleteClick}
                  handleChange={handleChangeClick}
                />
              </Col>
            </Row>
          )}
        </CardBody>
      </Card>
      <TagAction
        isEdit={isEdit}
        isOpen={isActionModal}
        toggle={actionModalToggle}
        tag={singleTag}
      />
      <TagDelete id={id} isOpen={isDeleteModal} toggle={deleteModalToggle} />
    </div>
  );
};

export default Tags;
