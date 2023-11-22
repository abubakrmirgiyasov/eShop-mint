import React, {ChangeEvent, FC} from 'react';

interface ITagTableColumnController {
    isShownTranslateColumn: boolean;
    onSwitchColumn: (omit: boolean) => void;
}

const TagTableColumnController: FC<ITagTableColumnController> = ({ isShownTranslateColumn, onSwitchColumn }) => {
    const onChange = (e: ChangeEvent<HTMLInputElement>) => {
        // e.currentTarget.checked = !e.currentTarget.checked;

        switch (e.currentTarget.name) {
            case "translate":
                onSwitchColumn(!e.currentTarget.checked);
                break;
        }
    };

    return (
        <React.Fragment>
            <div className={"form-check form-switch form-switch-success"}>
                <label className={"form-check-label"}>
                    <input
                        id={"flexSwitchCheckDefault"}
                        className={"form-check-input"}
                        role={"switch"}
                        type={"checkbox"}
                        name={"translate"}
                        defaultChecked={!isShownTranslateColumn}
                        onChange={onChange}
                    />
                    Перевод
                </label>
            </div>
        </React.Fragment>
    );
};

export default TagTableColumnController;