from app import app
from flask import flash, request, jsonify
import sqlhelper
from authhelper import require_appkey

@app.route('/projects')
@require_appkey
def projects():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllProjects")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project/<int:id>', methods=['GET'])
@require_appkey
def project(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetProject(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project', methods=['POST'])
@require_appkey
def project_add():
    try:
        content = request.json

        print(content)
        _projectId = content['ProjectIdentifier']
        _projectName = content['ProjectName']
        _projectDesc = content['ProjectDescription']
        _appDate = content['ApplicationDate']
        _grantApprovedDate = content['DateGrantApproved']
        _grantPaidDate = content['DateGrantPaid']
        _targetCompletion = content['TargetCompletionDate']
        _grantRequested = content['AmountGrantRequested']
        _grantApproved = content['AmountGrantApproved']
        _grantRecommended = content['AmountGrantRecommended']
        _grantPaid = content['AmountGrantPaid']
        _totalCost = content['TotalProjectCost']
        _statusCodeId = content['StatusCode_Id']
        _statusCodeDate = content['StatusCodeDate']
        _regionId = content['Region_Id']
        _districtId = content['District_Id']
        _projectOfficerId = content['ProjOfficer_Id']
        
        sql = "CALL usp_InsertProject(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (_projectId, _projectName, _projectDesc, _appDate, _grantApprovedDate, _grantPaidDate, _targetCompletion, _grantRequested, _grantApproved,
                _grantRecommended, _grantPaid, _totalCost, _statusCodeId, _statusCodeDate, _regionId, _districtId, _projectOfficerId,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/project/<int:id>', methods=['DELETE'])
@require_appkey
def delete_project(id):
    try:
        sql = "CALL usp_DeleteProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project/<int:id>', methods=['PUT'])
@require_appkey
def update_project(id):
    try:
        content = request.json
        _projectId = content['ProjectIdentifier']
        _projectName = content['ProjectName']
        _projectDesc = content['ProjectDescription']
        _appDate = content['ApplicationDate']
        _grantApprovedDate = content['DateGrantApproved']
        _grantPaidDate = content['DateGrantPaid']
        _targetCompletion = content['TargetCompletionDate']
        _grantRequested = content['AmountGrantRequested']
        _grantRecommended = content['AmountGrantRecommended']
        _grantApproved = content['AmountGrantApproved']
        _grantPaid = content['AmountGrantPaid']
        _totalCost = content['TotalProjectCost']
        _statusCodeId = content['StatusCode_Id']
        _regionId = content['Region_Id']
        _districtId = content['District_Id']
        _projectOfficerId = content['ProjOfficer_Id']
        _lastUpdatedBy = content['LastUpdatedBy']

        sql = "CALL usp_UpdateProjectDetails(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (id, _projectId, _projectName, _projectDesc, _appDate, _grantApprovedDate, _grantPaidDate, _targetCompletion, _grantRequested, _grantRecommended, _grantApproved,
                _grantPaid, _totalCost, _statusCodeId, _regionId, _districtId, _projectOfficerId, _lastUpdatedBy,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project/<int:id>/notes', methods=['PUT'])
@require_appkey
def update_project_notes(id):
    try:
        content = request.json
        _statusDesc = content['StatusDescription'] 
        _projOfficerRec = content['ProjOfficerRecommendation']
        _keywords = content['Keywords']
        _summary = content['Summary']
        _problems = content['Problems']
        _strengthsWeaknesses = content['StrengthsWeaknesses']
        _financeOtherFunders = content['FinanceOtherFunders']
        _localContrib = content['LocalContribution']
        _lastUpdatedBy = content['LastUpdatedBy']

        sql = "CALL usp_UpdateProjectNotes(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (id, _statusDesc, _projOfficerRec, _keywords, _summary, _problems, _strengthsWeaknesses, _financeOtherFunders, _localContrib, _lastUpdatedBy,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project/<int:id>/metadata', methods=['PUT'])
@require_appkey
def update_project_metadata(id):
    try:
        content = request.json
        _impact = content['Impact'] 
        _websitePicture = content['WebsitePicture']
        _caption = content['Caption']
        _latitude = content['Latitude']
        _longitude = content['Longitude']
        _lastUpdatedBy = content['LastUpdatedBy']

        sql = "CALL usp_UpdateProjectMetadata(%s,%s,%s,%s,%s,%s,%s)"
        data = (id, _impact, _websitePicture, _caption, _latitude, _longitude, _lastUpdatedBy,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)